//
//  DiagnosisFieldCombobox.m
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DiagnosisFieldCombobox.h"

@implementation DiagnosisFieldCombobox{
    
}

- (instancetype)initWithTitle:(NSString*)title arrayChoices:(NSArray*)choices{
    self = [self initWithTitle:title type:DiagnosisFieldTypeComboBox];
    self.arrayChoices = choices;
    return self;
}

@end
