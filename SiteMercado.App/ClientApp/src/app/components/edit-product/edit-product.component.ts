import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutService } from 'src/app/services/produt.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  editProductForm: FormGroup;
  produto: Produto;

  constructor(private service: ProdutService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.service.showProducts(this.route.snapshot.params.id).subscribe(data =>{
      this.produto = data;

      this.editProductForm = this.fb.group({
        id: data.id,
        nome: [data.nome, Validators.required],
        valor: [data.valor, Validators.required],
        imagem: [data.imagem, Validators.required],
      })
    })
  }

  onSubmit() {
    this.service.editProducts(this.editProductForm.value).subscribe(data => {
      this.router.navigate(["/produtos"])
    })
  }

}
