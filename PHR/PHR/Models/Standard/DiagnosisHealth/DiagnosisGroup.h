//
//  DiagnosisGroup.h
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DiagnosisGroup : NSObject{
    
}
@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSArray *arrayField;

- (instancetype)initWithTitle:(NSString*)title fields:(NSArray*)fields;

@end
