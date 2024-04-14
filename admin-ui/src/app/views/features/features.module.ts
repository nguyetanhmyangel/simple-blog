import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { FeaturesRoutingModule } from './features-routing.module';


@NgModule({
  declarations: [
    // LoginComponent,
    // RegisterComponent,
    // Page404Component,
    // Page500Component
  ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule
  ]
})
export class FeaturesModule {
}
