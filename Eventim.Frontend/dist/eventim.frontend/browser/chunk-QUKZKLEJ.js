import{da as o,h as s,k as n}from"./chunk-E7HQOLS5.js";var c=(()=>{let e=class e{constructor(r){this.apiService=r,this.addExpense=t=>this.apiService.post("Expenses",t,{}),this.getExpensesByGroup=t=>this.apiService.get("Expenses/GetExpensesByGroup/"+t,{}),this.getBalanceByGroup=t=>this.apiService.get("Expenses/GetBalanceByGroup/"+t,{})}};e.\u0275fac=function(t){return new(t||e)(n(o))},e.\u0275prov=s({token:e,factory:e.\u0275fac,providedIn:"root"});let i=e;return i})();export{c as a};