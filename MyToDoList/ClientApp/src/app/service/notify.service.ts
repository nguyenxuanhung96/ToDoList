import { Inject, Injectable } from '@angular/core'
import { ResponseBaseModel, ResponseBaseMessage } from '../model/commons/ResponseBaseModel';

import * as toastr from 'toastr'

@Injectable()
export class NotifyService {

    constructor() {
        toastr.options.closeButton = true;
    }

    success(message: string) {
        toastr.success(message);
    }

    warning(message: string) {
        toastr.warning(message);
    }

    error(message: string) {
        toastr.error(message);
    }

    info(message: string) {
        toastr.info(message);
    }

    notify(response: any) {
        response = response as ResponseBaseModel;
        if (response) {
            if (response.isSuccess) {
                if (response.message) {
                    this.success(response.message);
                } else {
                    this.success(ResponseBaseMessage.Success);
                }
            } else {
                if (response.message) {
                    this.error(response.message);
                } else {
                    this.error(ResponseBaseMessage.Failed);
                }
            }
        }
    }
}
