//
//  MFRession.h
//  PHR
//
//  Created by DEV-MinhNN on 11/17/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@interface MFRession : JSONModel

@property (nonatomic, strong) NSString<Optional> *message;
@property (nonatomic, strong) NSString<Optional> *status;
@property (nonatomic, strong) NSDictionary<Optional> *content;

+ (MFRession *)responseObjectWithRequestOperation:(NSDictionary *)operation
                                             error:(NSError *)error;

@end
