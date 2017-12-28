//
//  DiagnosisFieldCombobox.h
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "DiagnosisField.h"

@interface DiagnosisFieldCombobox : DiagnosisField {
    
}
@property (strong, nonatomic) NSArray *arrayChoices;

- (instancetype)initWithTitle:(NSString*)title arrayChoices:(NSArray*)choices;


@end
