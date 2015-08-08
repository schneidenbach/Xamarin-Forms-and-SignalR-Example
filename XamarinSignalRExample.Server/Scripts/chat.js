(function ($) {
    $(function () {
        var chatInput = $("#chat-input");
        var userName;

        //ask for a username
        setTimeout(function () {
            userName = prompt("Please enter a username.");
        }, 0);

        var chat = $.connection.chat;
        var chatWindow = $("#chat-window");

        //this is the function that's run when the "messageReceived" function is called from the server
        chat.client.messageReceived = function (username, message) {
            chatWindow.append("<div><strong>" + username + ": </strong>" + message + "</div>");
        };

        $.connection.hub.start().done(function () {
            chatInput.keydown(function (e) {

                if (e.which === 13) {
                    var text = chatInput.val();

                    //empty the textbox
                    chatInput.val("");

                    //send the message to the server
                    chat.server.sendMessage(userName, text);

                    //focus cursor on the textbox for easy chatting!
                    self.focus();
                }
            });
        });
    });
})(jQuery);