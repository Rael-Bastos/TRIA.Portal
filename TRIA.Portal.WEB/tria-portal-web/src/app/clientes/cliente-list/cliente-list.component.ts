import { Component, OnInit } from '@angular/core';
import { EMPTY } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { AlertModalService } from 'src/app/service/alert-modal.service';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
clientes:any=[];
constructor(private _apiService: ApiService, private _alertService: AlertModalService) { }

ngOnInit() {
  this._apiService.getApi("ClienteContato/ConsultarTodos").subscribe(
    (retorno)=>{
      if(retorno.isOk)
      this.clientes = retorno.objetoRetorno;
      else{
        console.error(retorno.mensagemRetorno);
        this._alertService.showError("Error ao consultar clientes, tente novamente!")
      }

    },
    (error) =>{console.error(error);
      this._alertService.showError("Error ao consultar clientes, tente novamente!")
    }
  )
}

onDelete(id:number){
  const result$ = this._alertService.showConfirm('Confirmação','Deseja excluir esse cliente?');

  result$.asObservable()
  .pipe(take(1),
    switchMap(result => result ? this._apiService.getApi("ClienteContato/Deletar/".concat(id.toString())) : EMPTY)
  ).subscribe(success =>{
      if(success.isOk)
      this.ngOnInit();
      else{
        console.error(success.mensagemRetorno);
        this._alertService.showError("Error ao deletar, tente novamente!")
      }
    },error =>{
      console.error(error);
      this._alertService.showError("Error ao deletar, tente novamente!")
    }
  )
}
onEdit(id: number){

}

}
