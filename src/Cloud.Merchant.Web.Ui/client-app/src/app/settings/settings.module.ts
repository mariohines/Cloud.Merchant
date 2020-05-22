import { NgModule } from '@angular/core';
import {CommonModule} from "@angular/common";

import * as moduleComponents from './components';

@NgModule({
  declarations: [moduleComponents.components],
  imports: [
    CommonModule
  ]
})
export class SettingsModule { }
