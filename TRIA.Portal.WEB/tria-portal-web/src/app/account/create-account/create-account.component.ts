import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertModalService } from 'src/app/service/alert-modal.service';
import { AccountService } from '../shared/account.service';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  account={
    id:0,
    usuario:'',
    nomeCompleto:'',
    email:'',
    senha:'',
    perfil:''
  }
  constructor(private _accountService: AccountService, private router: Router, private _alertModal: AlertModalService) { }

  ngOnInit(): void {
  }

 async onSubmit(){
    try {
      const result = await this._accountService.createAccount(this.account);
      console.log(`Conta criada ${result}`);


      this.router.navigate(['']);

    } catch (error) {
      console.error(error);
      this._alertModal.showError("Error ao criar conta, tente novamente!")
    }
  }

}
