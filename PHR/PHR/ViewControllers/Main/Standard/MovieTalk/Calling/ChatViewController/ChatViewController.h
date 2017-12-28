//
//  ChatViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "JSQMessagesViewController.h"
#import "MessageModel.h"
#import "JSQMessage.h"

@interface ChatViewController: JSQMessagesViewController <JSQMessagesComposerTextViewPasteDelegate>

@property (strong, nonatomic) MessageModel *messageModel;

- (void)handleIncomingMessage:(NSString*)incomingMessage;
@end
