import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProdutService {

  _baseURL: string = "http://localhost:52075/api/produtos";

  constructor(private http: HttpClient) { }

  getAllProducts() {
    return this.http.get<Produto[]>(this._baseURL)
  }


  addProducts(produto: Produto) {
    return this.http.post(this._baseURL + "/AddProduto", produto);
  }

  editProducts(produto: Produto) {
    return this.http.put(this._baseURL + "/editaproduto/" +produto.id, produto);
  }

  showProducts(id: number) {
    return this.http.get<Produto>(this._baseURL + "/mostraproduto/" + id);
  }

  deletaProduto(id: number) {
    return this.http.delete(this._baseURL + "/deletaproduto/" + id);
  }

}
