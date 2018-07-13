import { Component, OnInit } from '@angular/core';
import { RamService } from '../services/ram/ram.service';
import { HttpClient } from 'selenium-webdriver/http';

interface ChartDataPoint {
  name: string;
  value: number;
}

interface ChartData {
  name: string;
  series: ChartDataPoint[];
}

@Component({
  selector: 'app-ram-usage',
  templateUrl: './ram-usage.component.html',
  styleUrls: ['./ram-usage.component.css']
})
export class RamUsageComponent implements OnInit {

  num = 0;
  private _free: number;
  private _used: number;

  // single = [
  //   {
  //     'name': 'RAM',
  //     'value': 8940000
  //   }
  // ];

  multi: ChartData[] = [
    {
      name: 'RAM',
      series: []
    }
  ];

  view: any[] = [800, 600];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Number';
  showYAxisLabel = true;
  yAxisLabel = 'Bytes';
  timeline = true;

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  // line, area
  autoScale = true;

  onSelect(event) {
    console.log(event);
  }

  constructor(private _service: RamService) {
    this._service.ram.subscribe(ram => {
      this._used = ram.used;
      this.multi[0].series.push({
        name: this.formatBytes(ram.used, 0),
        value: ram.used
      });

      if (this.multi[0].series.length > 10) {
        this.multi[0].series = this.multi[0].series.slice(0, 10);
      }

      this.multi = [
        {
          name: 'RAM',
          series: this.multi[0].series
        }
      ];

      // this.multi[0].series.push({
      //   name: this.formatBytes(ram.used, 0),
      //   value: ram.used
      // });
    });
  }

  ngOnInit() {
  }

  formatBytes(bytes, decimals): string {
    if (bytes === 0) { return '0 Bytes'; }
    const k = 1024;
    const dm = decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }
}


