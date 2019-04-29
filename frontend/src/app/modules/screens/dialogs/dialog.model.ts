class Dialog {
    public id?: number;
    public firstUser?: User;
    public secondUser?: User;
    public messages: Message[];
}

class User {
    public id?: string;
    public firstName?: string;
    public secondName?: string;
}

class Message {
    public id: number;
    public messageBody: string;
    sentTime: Date;
}

class SendMessage {
    dialogId?: number;
    messageFrom: string;
    messageTo: string;
    messageBody: string;
    sentTime: Date;
}
