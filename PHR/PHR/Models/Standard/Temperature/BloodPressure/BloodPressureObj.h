//
//  BloodPressureObj.h
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface BloodPressureObj : NSObject

- (id)initWithBloodPressure:(float)bloodPressure andDate:(NSString *)date;

@property (nonatomic) float bloodPressure;
@property (nonatomic, strong) NSString *date;

@end
