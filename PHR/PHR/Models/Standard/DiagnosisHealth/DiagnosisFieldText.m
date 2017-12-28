//
//  DianosisFieldText.m
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DiagnosisFieldText.h"

@implementation DiagnosisFieldText{
    
}

- (instancetype)initWithTitle:(NSString*)title placeholder:(NSString*)placeholder{
    self = [self initWithTitle:title type:DiagnosisFieldTypeText];
    self.placeholder = placeholder;
    return self;
}

@end
