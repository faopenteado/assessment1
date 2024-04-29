import{a as N}from"./chunk-B3KTP4IA.js";import{a as z}from"./chunk-QUKZKLEJ.js";import{a as $}from"./chunk-5PHZXZNU.js";import{l as j,m as R}from"./chunk-DVSPLOIY.js";import{$ as L,A as a,B as i,C as g,E as M,G as _,H as s,I as F,J as d,K as P,M as v,N as G,O,R as w,S as C,T,U as k,V as I,Y as B,aa as A,ca as D,i as y,m as u,n as b,t as p,u as x,x as f,y as l}from"./chunk-E7HQOLS5.js";var q=(()=>{let e=class e{};e.\u0275fac=function(t){return new(t||e)},e.\u0275cmp=u({type:e,selectors:[["app-group-people-list"]],inputs:{groupPeople:"groupPeople"},standalone:!0,features:[v],decls:2,vars:1,template:function(t,r){t&1&&(a(0,"li"),s(1),i()),t&2&&(p(),d(" ",r.groupPeople.name,`
`))},styles:["li[_ngcontent-%COMP%]{height:35px;font-size:1.3em;color:#727171;margin:2px;padding-top:10px}"]});let n=e;return n})();var Y=(()=>{let e=class e{formatDate(o){let t=new Date(o),r=new Date;return t.getDate()+"/"+t.getMonth()+"/"+t.getFullYear()}calculateDiff(o){let t=new Date,r=new Date(o);var E=t.getTime()-r.getTime(),c=E/1e3;return c<60?Math.floor(c)+" seconds ago":(c=c/60,c<60?Math.floor(c)+" minutes ago":(c=c/60,c<24?Math.floor(c)+" hours ago":Math.floor(c)+" days ago"))}};e.\u0275fac=function(t){return new(t||e)},e.\u0275cmp=u({type:e,selectors:[["app-group-expenses"]],inputs:{expense:"expense"},standalone:!0,features:[v],decls:8,vars:4,consts:[[1,"time"]],template:function(t,r){t&1&&(a(0,"li")(1,"span")(2,"b"),s(3),i(),s(4),i(),g(5,"br"),a(6,"span",0),s(7),i()()),t&2&&(p(3),d("",r.expense.peopleName,":"),p(),P(" \u20AC ",r.expense.amount," - ",r.expense.description," "),p(3),d(" ",r.calculateDiff(r.expense.date)," "))},styles:[".time[_ngcontent-%COMP%]{font-size:.8em;color:#bbb}li[_ngcontent-%COMP%]{padding:5px;margin-left:5px}"]});let n=e;return n})();function V(n,e){if(n&1&&(a(0,"li")(1,"span"),s(2),i(),a(3,"span",3),s(4),G(5,"number"),i()()),n&2){let m=e.$implicit;p(2),d("",m.personName,": "),p(),l("ngClass",m.amount>=0?"green":"red"),p(),d(" ",O(5,3,m.amount,".2-2")," ")}}var S=(()=>{let e=class e{};e.\u0275fac=function(t){return new(t||e)},e.\u0275cmp=u({type:e,selectors:[["app-balance"]],inputs:{balance:"balance"},standalone:!0,features:[v],decls:9,vars:2,consts:[[1,"container"],[1,"row"],[4,"ngFor","ngForOf"],[3,"ngClass"]],template:function(t,r){t&1&&(a(0,"div",0)(1,"div",1)(2,"h3"),s(3,"Balance"),i()(),a(4,"div",1)(5,"span"),s(6),i()(),a(7,"ul"),f(8,V,6,6,"li",2),i()()),t&2&&(p(6),d("Total spent: ",r.balance.total,""),p(2),l("ngForOf",r.balance.expensesBalance))},dependencies:[I,w,C,k],styles:[".green[_ngcontent-%COMP%]{color:#82f182}.red[_ngcontent-%COMP%]{color:red}li[_ngcontent-%COMP%]{padding:3px}"]});let n=e;return n})();function X(n,e){if(n&1&&g(0,"app-group-people-list",12),n&2){let m=e.$implicit;l("groupPeople",m)}}function Z(n,e){if(n&1&&(a(0,"div",1)(1,"ul"),f(2,X,1,1,"app-group-people-list",11),i()()),n&2){let m=M();p(2),l("ngForOf",m.people)}}function ee(n,e){n&1&&(a(0,"div",1)(1,"span",13),s(2,"Add someone here!"),i()())}function te(n,e){if(n&1&&g(0,"app-group-expenses",15),n&2){let m=e.$implicit;l("expense",m)}}function ne(n,e){if(n&1&&(a(0,"div",1)(1,"ul"),f(2,te,1,1,"app-group-expenses",14),i()()),n&2){let m=M();p(2),l("ngForOf",m.expenses)}}function ie(n,e){n&1&&(a(0,"div",1)(1,"span",13),s(2,"It look likes no one spent money..."),i()())}var H=(()=>{let e=class e{constructor(o,t,r,E){this.groupPeopleService=o,this.groupService=t,this.route=r,this.expensesService=E,this.groupId=0,this.group={name:"",id:0},this.people=[],this.expenses=[],this.balance={expensesBalance:[],total:0}}ngOnInit(){this.route.params.subscribe(o=>{this.groupId=o.id}),this.getGroup(this.groupId),this.getPeople(this.groupId),this.getExpenses(this.groupId),this.getBalance(this.groupId)}getPeople(o){this.groupPeopleService.getPeopleOnGroup(this.groupId).subscribe({next:t=>{this.people=t},error:t=>{alert(t.message)}})}getGroup(o){this.groupService.getGroup(o,{page:0,perPage:150}).subscribe({next:t=>{this.group=t},error(t){alert(t.message)}})}getExpenses(o){this.expensesService.getExpensesByGroup(o).subscribe({next:t=>{this.expenses=t},error(t){alert(t.message)}})}getBalance(o){this.expensesService.getBalanceByGroup(o).subscribe({next:t=>{this.balance=t},error(t){alert(t.message)}})}};e.\u0275fac=function(t){return new(t||e)(x($),x(N),x(B),x(z))},e.\u0275cmp=u({type:e,selectors:[["app-group-detail"]],inputs:{group:"group"},decls:26,vars:10,consts:[[1,"container"],[1,"row"],["type","button","routerLinkActive","active",1,"btn","mr-15",3,"routerLink"],["type","button","routerLinkActive","active",1,"btn",3,"routerLink"],["type","button","routerLink","/","routerLinkActive","active",1,"btn","btn-cancel","ml-15"],[1,"row","mt-15"],[1,"column"],[1,"row","mt-25"],["class","row",4,"ngIf"],[1,"column","borderleft"],[3,"balance"],[3,"groupPeople",4,"ngFor","ngForOf"],[3,"groupPeople"],[1,"label","mt-25"],[3,"expense",4,"ngFor","ngForOf"],[3,"expense"]],template:function(t,r){t&1&&(a(0,"div",0)(1,"h2"),s(2),i(),a(3,"div",1)(4,"button",2),s(5," Add people on group "),i(),a(6,"button",3),s(7," Add expenses "),i(),a(8,"button",4),s(9," Cancel "),i()(),a(10,"div",5)(11,"div",6)(12,"div",7)(13,"h3"),s(14,"Members"),i()(),f(15,Z,3,1,"div",8)(16,ee,3,0,"div",8),i(),a(17,"div",9)(18,"div",7)(19,"h3"),s(20,"Expenses"),i()(),f(21,ne,3,1,"div",8)(22,ie,3,0,"div",8),i(),a(23,"div",9)(24,"div",7),g(25,"app-balance",10),i()()()()),t&2&&(p(2),F(r.group.name),p(2),_("routerLink","/add-people-on-group/",r.groupId,""),p(2),_("routerLink","/add-expense/",r.groupId,""),p(9),l("ngIf",r.people.length>0),p(),l("ngIf",r.people.length==0),p(5),l("ngIf",r.expenses.length>0),p(),l("ngIf",r.people.length==0),p(3),l("balance",r.balance))},dependencies:[C,T,L,A,q,Y,S],styles:["ul[_ngcontent-%COMP%]{list-style-type:square}"]});let n=e;return n})();var oe=[{path:"",component:H}],J=(()=>{let e=class e{};e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=b({type:e}),e.\u0275inj=y({imports:[D.forChild(oe),D]});let n=e;return n})();var Ee=(()=>{let e=class e{};e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=b({type:e}),e.\u0275inj=y({imports:[I,J,j,R,S]});let n=e;return n})();export{Ee as GroupDetailModule};