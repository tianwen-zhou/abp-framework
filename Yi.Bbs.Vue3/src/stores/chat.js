import { defineStore } from "pinia";
const chatStore = defineStore("chat", {
  state: () => ({
    userList: [],
    msgList: []
  }),
  getters: {
    allMsgContext: (state) => state.msgList.filter(x => x.messageType == "All"),
    personalMsgContext: (state) => state.msgList.filter(x => x.messageType == "Personal"),
    aiMsgContext: (state) => state.msgList.filter(x => x.messageType == "Ai")
  },
  actions:
  {
    addOrUpdateMsg(msg) {
      var currentMsg = this.msgList.filter(x => x.id == msg.id)[0];
      //当前没有包含,如果有相同的上下文id，只需要改变content即可
      if (currentMsg == undefined) {
        this.addMsg(msg);
      }
      else {
        currentMsg.content += msg.content;
      }

    },
    clearAiMsg()
    {
      this.msgList=this.msgList.filter(x => x.messageType != "Ai")
    },
    setMsgList(value) {
      this.msgList = value;
    },
    addMsg(msg) {
      this.msgList.push(msg);
    },
    setUserList(value) {
      this.userList = value;
    },
    addUser(user) {
      this.userList.push(user);
    },
    delUser(userId) {
      this.userList = this.userList.filter(obj => obj.userId != userId);
    }
  },
});

export default chatStore;
