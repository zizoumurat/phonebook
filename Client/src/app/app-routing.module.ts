import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const appRoutes: Routes = [
  {
    path: 'users',
    loadChildren: () => import('./presentation/users/users.module').then(m => m.UsersModule),
  },
  {
    path: 'reports',
    loadChildren: () => import('./presentation/reports/reports.module').then(m => m.ReportsModule),
  },
  {
    path: '**',
    redirectTo: 'users',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
