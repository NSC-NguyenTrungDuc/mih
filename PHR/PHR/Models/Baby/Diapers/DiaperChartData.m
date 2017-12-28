//
//  DiaperChartData.m
//  PHR
//
//  Created by BillyMobile on 6/9/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "DiaperChartData.h"

@implementation DiaperChartData

- (PHRSample*)sampleFromDiaperChartData {
    PHRSample *sample = [[PHRSample alloc] init];

    sample.value = self.numberOfPoo;
    sample.value2 = self.numberOfPee;

    sample.record_date = [UIUtils dateFromServerTimeString:self.time_pee_poo];
    sample.source_bundle = [PHRSample bundlePHRServer];
    return sample;
}

@end
