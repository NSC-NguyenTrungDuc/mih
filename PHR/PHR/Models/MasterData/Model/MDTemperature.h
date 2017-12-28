//
//  MDTemperature.h
//  PHR
//
//  Created by Luong Le Hoang on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface MDTemperature : MDBase

@property (assign, nonatomic) double low;
@property (assign, nonatomic) double high;
@property (assign, nonatomic) double normalMin;
@property (assign, nonatomic) double normalMax;

@end
