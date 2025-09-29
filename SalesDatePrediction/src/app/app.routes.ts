import { Routes } from '@angular/router';
import { DatePredictionComponent } from './pages/date-prediction/date-prediction.component';

export const routes: Routes = [
    { path: '', component: DatePredictionComponent },
    { path: 'date-prediction', component: DatePredictionComponent }
];
