//
//  DiagnosisGroup.m
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DiagnosisGroup.h"

@implementation DiagnosisGroup{
    
}

- (instancetype)init{
    if (self = [super init]) {
        
    }
    return self;
}

- (instancetype)initWithTitle:(NSString*)title fields:(NSArray*)fields{
    self = [self init];
    self.title = title;
    self.arrayField = fields;
    return self;
}

@end
