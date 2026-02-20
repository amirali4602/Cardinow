import { Routes } from '@angular/router';
import { DashboardComponent } from './features/dashboard.component/dashboard.component';
import { SimpleAuthGuard } from './core/guards/simple-auth.guard-guard';
import { SettingsComponent } from './features/settings.component/settings.component';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboards', pathMatch: 'full' },
  {
    path:'',
    children:[
      {
        path:'dashboards',
        component:DashboardComponent,
        title:'Dashboard'
      },
      {
        path: 'settings', 
        component: SettingsComponent,
        canActivate: [SimpleAuthGuard],
        title:'Settings Title'
      }
    ]
  }
  
  
];
