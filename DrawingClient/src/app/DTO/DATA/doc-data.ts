import { DocIdDTO } from "./doc-id-dto";

export class DocDATA {
    constructor(public ownerId:string,public docId:string,public docUrl:string,public docName:string) {}
}
