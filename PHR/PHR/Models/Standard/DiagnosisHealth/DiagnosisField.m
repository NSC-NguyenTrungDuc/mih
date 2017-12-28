//
//  DiagnosisField.m
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DiagnosisField.h"

@implementation DiagnosisField{
    
}

- (instancetype)initWithTitle:(NSString*)title type:(DiagnosisFieldType)type{
    if (self = [super init]) {
        self.title = title;
        _type = type;
    }
    return self;
}

@end
