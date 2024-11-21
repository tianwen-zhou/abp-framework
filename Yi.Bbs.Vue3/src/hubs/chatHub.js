import signalR from "@/utils/signalR";
import useChatStore from "@/stores/chat";

const receiveMsg = (connection) => {
    const chatStore = useChatStore();
    //上线用户
    connection.on("liveUser", (user) => {
        chatStore.addUser(user);
    });
    //下线用户
    connection.on("offlineUser", (userId) => {
        chatStore.delUser(userId);
    });
    //接受其他用户消息
    connection.on("receiveMsg", (type, content) => {
        const letChatStore = useChatStore();
        //如果是ai消息，还要进行流式显示
       // alert(type)
        if (type == 3) {
            letChatStore.addOrUpdateMsg(content);
        }
        else {
            letChatStore.addMsg(content);
        }


    });
    //用户状态-正在输入中，无
    connection.on("userStatus", (type) => {

    });
};
export function start() {
    signalR.start(`chat`, receiveMsg);
}
export function close() {
    signalR.SR.stop();
}

