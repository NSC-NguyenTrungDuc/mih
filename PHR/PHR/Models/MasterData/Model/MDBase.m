//
//  MDBase.m
//  PHR
//
//  Created by Luong Le Hoang on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MDBase.h"

@implementation MDBase

- (void)setAgeMeanSdValues:(NSArray*)array{
    self.age = [array[0] intValue];
    self.mean = [array[1] doubleValue];
    self.sd = [array[2] doubleValue];
}

@end
