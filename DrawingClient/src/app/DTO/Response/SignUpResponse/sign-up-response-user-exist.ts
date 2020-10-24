import { SignUpResponse } from "./sign-up-response";

export class SignUpResponseUserExist extends SignUpResponse {
    responseType='RegisterResponseUserExist';
    responseMessage= 'User Exist try again';
}
