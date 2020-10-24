export class SignUpRequest {
    constructor(public userName: string,
        public Login: {
            userEmail: string,
            userPassword: string
        }
    ) { }
}
