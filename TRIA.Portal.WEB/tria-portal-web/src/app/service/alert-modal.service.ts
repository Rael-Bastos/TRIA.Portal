import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlertModalComponent } from '../shared/alert-modal/alert-modal.component';
import { ConfirmModalComponent } from '../shared/confirm-modal/confirm-modal.component';

export enum AlertTypes{
  Danger= 'danger',
  Success= 'sucess'
}

@Injectable({
  providedIn: 'root'
})
export class AlertModalService {

constructor(private modalService: BsModalService) { }

  showConfirm(title: string, body: string, okTxt?: string, cancelTxt?:string){
    const bsModalRef: BsModalRef = this.modalService.show(ConfirmModalComponent);
    bsModalRef.content.title = title;
    bsModalRef.content.body = body;
    if(okTxt)
      bsModalRef.content.okTxt = okTxt;
    if(cancelTxt)
      bsModalRef.content.cancelTxt = cancelTxt;

    return(<ConfirmModalComponent>bsModalRef.content).confirmResult;

  }
  showSucess(message: string){
    const bsModalRef: BsModalRef = this.modalService.show(AlertModalComponent);
    bsModalRef.content.message = message;

  }
  showError(message: string){
    const bsModalRef: BsModalRef = this.modalService.show(AlertModalComponent);
    bsModalRef.content.message = message;
    bsModalRef.content.type = 'danger';

  }
}
