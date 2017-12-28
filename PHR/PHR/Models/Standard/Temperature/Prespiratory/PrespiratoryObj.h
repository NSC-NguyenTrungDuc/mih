//
//  PrespiratoryObj.h
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PrespiratoryObj : NSObject

- (id)initWithPrespiratory:(float)prespiratory andDate:(NSString *)date;

@property (nonatomic) float prespiratory;
@property (nonatomic, strong) NSString *date;

@end
