import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertModalService } from 'src/app/service/alert-modal.service';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {

  title: string= "Novo";
  id: number=0;
  produtos: any =[]
  cliente: any ={
    id:0,
    nmEmpresa:"",
    nmCliente:"",
    telefone:"",
    email:"",
    textoLivre:"",
    dtInclusao: new Date(),
    hrAtendimento:"",
    idProdutoServico:0,

  }
  constructor(private _apiService: ApiService, private _alertService: AlertModalService, private router: Router
    ,private route: ActivatedRoute) { }


  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get('id')!);
    this.title = this.id === 0 ? 'Novo' : 'Editar';

    if(this.id > 0){
      this._apiService.getApi("ClienteContato/ConsultarPorId/".concat(this.id.toString())).subscribe(sucess => {
        if(sucess.isOk)
        this.cliente = sucess.objetoRetorno
        else{
          console.error(sucess.mensagemRetorno);
          this._alertService.showError("Error ao Consultar, tente novamente!")
        }
      },error =>{
        console.error(error);
        this._alertService.showError("Error ao Consultar, tente novamente!")
      });


    }
    this.buscarProdutos();
  }




  onSubmit(clienteForm: NgForm){
    this.cliente={
      id: clienteForm.value.id,
      nmEmpresa: clienteForm.value.nmEmpresa,
      nmCliente: clienteForm.value.nmCliente,
      telefone: clienteForm.value.telefone,
      email: clienteForm.value.email,
      textoLivre: clienteForm.value.textoLivre,
      dtInclusao: new Date(),
      dtAlteracao: new Date(),
      hrAtendimento: "",
      idProdutoServico: +clienteForm.value.idProdutoServico
    }

    var req: Observable<any>= new Observable();
    if(this.cliente.id > 0)
      req = this._apiService.postApi("ClienteContato/Alterar",this.cliente);
    else
      req = this._apiService.postApi("ClienteContato/Inserir",this.cliente);

      req.subscribe(sucess =>{
      if(sucess.isOk){
      this.router.navigate(["/clientes"])
      this._alertService.showSucess("Cliente salvo com sucesso!")}
      else{
        console.error(sucess.mensagemRetorno);
        this._alertService.showError("Error ao salvar, tente novamente!")
      }
    },error =>{
      console.error(error);
      this._alertService.showError("Error ao salvar, tente novamente!")
    });

  }

  buscarProdutos(){
    this._apiService.getApi("ProdutoServico/ConsultarTodos").subscribe(
      (retorno)=>{
        if(retorno.isOk)
        this.produtos = retorno.objetoRetorno;
        else{
          console.error(retorno.mensagemRetorno);
          this._alertService.showError("Error ao consultar produtos, tente novamente!")
        }

      },
      (error) =>{console.error(error);
        this._alertService.showError("Error ao consultar produtos, tente novamente!")
      }
    )
  }

}
