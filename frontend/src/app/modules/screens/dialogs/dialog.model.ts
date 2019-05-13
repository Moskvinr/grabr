export class Dialog {
    public id?: number;
    public firstUser?: User;
    public secondUser?: User;
    public messages: Message[];
}

export class User {
    public id?: string;
    public firstName?: string;
    public secondName?: string;
}

export class Message {
    constructor() { }
    public id: number;
    public messageBody: string;
    public sentTime: Date;
}

export class SendMessage {
    constructor() {}
    dialogId?: number;
    messageFrom: string;
    messageTo: string;
    messageBody: string;
    sentTime: Date;
}
