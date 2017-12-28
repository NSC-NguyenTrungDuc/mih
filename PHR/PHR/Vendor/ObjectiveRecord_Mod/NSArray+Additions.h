//
//  NSArray+Additions.h
//  IKEA
//
//  Created by Demigod on 07/01/2013.
//  Copyright (c) 2013 MEE. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSArray (Additions)
- (id) firstObject;
- (id) randomObject;
- (NSMutableArray *) toMutableArray;
- (NSArray *) sortWithKey:(NSString *) key ascending:(BOOL) ascending;
- (NSMutableArray *) sortMutableWithKey:(NSString *) key ascending:(BOOL) ascending;
- (void) sortMutableWithKey:(NSString *) key ascending:(BOOL) ascending completion:(void (^)(NSMutableArray *array))completionBlock;
- (NSMutableArray *) sortMutableWithKeys:(NSArray *) keys ascending:(NSArray *) ascendings;
- (void) sortMutableWithKeys:(NSArray *) keys ascending:(NSArray *) ascendings completion:(void (^)(NSMutableArray *array))completionBlock;
- (NSMutableArray *) filterMutableWithKey:(NSString *)key stringValue:(NSString *)value;

- (NSString *)connectStringArrayToStringWithSeparator:(NSString *)seperator;


@end
