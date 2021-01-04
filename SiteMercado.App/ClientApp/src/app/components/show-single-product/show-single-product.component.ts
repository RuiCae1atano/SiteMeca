import { Component, OnInit } from '@angular/core';
import { ProdutService } from '../../services/produt.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-show-single-product',
  templateUrl: './show-single-product.component.html',
  styleUrls: ['./show-single-product.component.css']
})
export class ShowSingleProductComponent implements OnInit {
  public produto: Produto;
  imagem;

  constructor(private service: ProdutService, private route: ActivatedRoute) { }

  ngOnInit() {
    // this.service.showProducts(this.route.snapshot.params.id).subscribe(data => {
    //    this.produto = data.produto;
    // })

    this.service.showProducts(this.route.snapshot.params.id).subscribe(data => {
      this.produto = data;
      this.imagem = data.imagem;
    })    
  }

}
