export interface ResponseBaseModel {
    isSuccess: boolean;
    message: string;
}

export enum ResponseBaseMessage {
    Success = "Successfully",
    Failed = "Failed, please try again!",
}
