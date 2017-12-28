//
//  TemperatureObj.h
//  PHR
//
//  Created by BillyMobile on 5/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TemperatureObj : NSObject

- (id)initWithTemperature:(float)temperature andDate:(NSString *)date;

@property (nonatomic) float temperature;
@property (nonatomic, strong) NSString *date;


@end
