//
//  DiagnosisField.h
//  PHR
//
//  Created by Luong Le Hoang on 10/6/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DiagnosisField : NSObject {
    
}
@property (strong, nonatomic) NSString *title;
@property (strong, nonatomic) NSString *value;
@property (assign, nonatomic, readonly) DiagnosisFieldType type;

- (instancetype)initWithTitle:(NSString*)title type:(DiagnosisFieldType)type;

@end
