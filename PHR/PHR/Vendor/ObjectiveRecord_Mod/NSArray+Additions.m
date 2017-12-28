//
//  NSArray+Additions.m
//  IKEA
//
//  Created by Demigod on 07/01/2013.
//  Copyright (c) 2013 MEE. All rights reserved.
//

#import "NSArray+Additions.h"

@implementation NSArray (Additions)
- (id) firstObject{
    if ([self count]>0) {
        return [self objectAtIndex:0];
    }
    return nil;
}

- (id) randomObject{
	return [self objectAtIndex:arc4random() % [self count]];
}

- (NSArray *) sortWithKey:(NSString *) key ascending:(BOOL) ascending{
    return [self sortedArrayUsingDescriptors:[NSArray arrayWithObject:[NSSortDescriptor sortDescriptorWithKey:key ascending:ascending]]];
}

- (NSMutableArray *) toMutableArray{
    NSMutableArray *array = [NSMutableArray array];
    for(id item in self){
        [array addObject:item];
    }
    return array;
}

- (NSMutableArray *) sortMutableWithKey:(NSString *) key ascending:(BOOL) ascending{
    NSArray *sortArray = [self sortedArrayUsingDescriptors:[NSArray arrayWithObject:[NSSortDescriptor sortDescriptorWithKey:key ascending:ascending]]];
    return [sortArray toMutableArray];
}

- (void) sortMutableWithKey:(NSString *) key ascending:(BOOL) ascending completion:(void (^)(NSMutableArray *array))completionBlock{
    dispatch_queue_t backgroundQueue = dispatch_queue_create("com.yourkidvid.sorting", 0);
    
    dispatch_async(backgroundQueue, ^{
        NSArray *sortArray = [self sortedArrayUsingDescriptors:[NSArray arrayWithObject:[NSSortDescriptor sortDescriptorWithKey:key ascending:ascending]]];
        
        dispatch_async(dispatch_get_main_queue(), ^{
            completionBlock([sortArray toMutableArray]);
        });
    });
}

- (void) sortMutableWithKeys:(NSArray *) keys ascending:(NSArray *) ascendings completion:(void (^)(NSMutableArray *array))completionBlock{
    dispatch_queue_t backgroundQueue = dispatch_queue_create("com.yourkidvid.sorting", 0);
    
    dispatch_async(backgroundQueue, ^{
        NSInteger count = 0;
        NSMutableArray *descriptors = [NSMutableArray array];
        for(NSString *key in keys){
            NSNumber *ascending = [ascendings objectAtIndex:count];
            [descriptors addObject:[NSSortDescriptor sortDescriptorWithKey:key ascending:[ascending boolValue]]];
            count++;
        }
        
        dispatch_async(dispatch_get_main_queue(), ^{
            if(descriptors.count > 0){
                NSArray *sortArray = [self sortedArrayUsingDescriptors:descriptors];
                completionBlock([sortArray toMutableArray]);
            }
            else{
                completionBlock([self toMutableArray]);
            }
        });
    });
}

- (NSMutableArray *) sortMutableWithKeys:(NSArray *) keys ascending:(NSArray *) ascendings{
    NSInteger count = 0;
    NSMutableArray *descriptors = [NSMutableArray array];
    for(NSString *key in keys){
        NSNumber *ascending = [ascendings objectAtIndex:count];
        [descriptors addObject:[NSSortDescriptor sortDescriptorWithKey:key ascending:[ascending boolValue]]];
        count++;
    }
    if(descriptors.count > 0){
        NSArray *sortArray = [self sortedArrayUsingDescriptors:descriptors];
        return [sortArray toMutableArray];
    }
    else{
        return [self toMutableArray];
    }
}

- (NSMutableArray *) filterMutableWithKey:(NSString *)key stringValue:(NSString *)value{
    NSMutableArray *results = [[NSMutableArray alloc]init];
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"%@ CONTAINS[cd] %@",
                              key, value];
    
    results = [NSMutableArray arrayWithArray:[self filteredArrayUsingPredicate:predicate]];
    
    return results;
}

- (NSString *)connectStringArrayToStringWithSeparator:(NSString *)seperator{
    NSString *result = @"";
    NSInteger total = self.count;
    for(NSInteger i = 0; i < total; i++){
        NSString *item = self[i];
        if(i < total - 1){
            result = [result stringByAppendingFormat:@"%@%@",item, seperator];
        }
        else{
            result = [result stringByAppendingFormat:@"%@",item];
        }
    }
    
    return result;
}
@end
