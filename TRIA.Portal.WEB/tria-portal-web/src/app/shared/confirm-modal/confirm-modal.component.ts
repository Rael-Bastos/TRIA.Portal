import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent implements OnInit {

  @Input() title: string="";
  @Input() body: string="";
  @Input() cancelTxt: string="Cancelar";
  @Input() okTxt: string="OK";

  confirmResult: Subject<boolean> = new Subject();

  constructor(private bsModalRef: BsModalRef) { }

  ngOnInit() {
    this.confirmResult = new Subject();
  }
  onConfirm(){
    this.confirmAndClose(true);
  }
  onClose(){
    this.confirmAndClose(false);
  }

  confirmAndClose(value: boolean){

    this.confirmResult.next(value);
    this.bsModalRef.hide();
  }


}
