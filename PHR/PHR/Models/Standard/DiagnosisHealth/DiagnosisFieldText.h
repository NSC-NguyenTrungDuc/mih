//
//  DianosisFieldText.h
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "DiagnosisField.h"

@interface DiagnosisFieldText : DiagnosisField{
    
}
@property (strong, nonatomic) NSString *placeholder;

- (instancetype)initWithTitle:(NSString*)title placeholder:(NSString*)placeholder;

@end
