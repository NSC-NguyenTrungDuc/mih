//
//  MessageModel.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "MessageModel.h"

@implementation MessageModel

- (instancetype)init {
  
  self = [super init];
  if (self) {
    
    self.messages = [[NSMutableArray alloc] init];
    JSQMessagesBubbleImageFactory *bubbleFactory = [[JSQMessagesBubbleImageFactory alloc] init];
    self.outgoingBubbleImageData = [bubbleFactory outgoingMessagesBubbleImageWithColor:[UIColor colorWithRed:199./255. green:237./255. blue:252./255. alpha:1]];
    self.incomingBubbleImageData = [bubbleFactory incomingMessagesBubbleImageWithColor:[UIColor colorWithRed:240./255. green:244./255. blue:248./255. alpha:1]];
  }
  return self;
}
@end
