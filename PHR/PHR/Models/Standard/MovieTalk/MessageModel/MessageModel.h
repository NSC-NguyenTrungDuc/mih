//
//  MessageModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "JSQMessages.h"

@interface MessageModel : NSObject

@property (strong, nonatomic) NSMutableArray *messages;
@property (strong, nonatomic) JSQMessagesBubbleImage *outgoingBubbleImageData;
@property (strong, nonatomic) JSQMessagesBubbleImage *incomingBubbleImageData;
@property (strong, nonatomic) NSString *profileId;

@end
