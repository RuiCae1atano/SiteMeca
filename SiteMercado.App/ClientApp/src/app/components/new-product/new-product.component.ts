import { Component, OnInit } from '@angular/core';
import { ProdutService } from '../../services/produt.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  addProductForm: FormGroup;

  constructor(private service: ProdutService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {

    this.addProductForm = this.fb.group({
      //id: [Math.floor(Math.random() * 1000)],
      nome: [null, Validators.required],
      valor: [null, Validators.required],
      imagem: [null, Validators.required],
    })
  }

  onSubmit() {
    this.service.addProducts(this.addProductForm.value).subscribe(data => {
      this.router.navigate(["/produtos"])
    })
  }

}
