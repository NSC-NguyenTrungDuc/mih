//package nta.med.ext.phr.service.impl;
//
//import java.nio.charset.Charset;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.Vertx;
//import org.vertx.java.core.buffer.Buffer;
//
//import com.google.protobuf.Message;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.ext.phr.glossary.Constant;
//import nta.med.ext.phr.service.MedApiService;
//import nta.med.service.ihis.proto.NuroServiceProto;
//
///**
// * @author DEV-TiepNM
// */
//@Service
//@Transactional
////@Transactional(value = DataSources.PHR)
//public class MedApiServiceImpl implements MedApiService {
//
//    @Autowired
//    private Vertx vertx;
//
//    public void createOUT0101(String username) {
//        NuroServiceProto.OUT0101PhrInsertRequest request = NuroServiceProto.OUT0101PhrInsertRequest.newBuilder()
//                .setHospCode(Constant.NTA).setSysId(Constant.PHR).setUserName(username).build();
//        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
//                getOptions().getExtension(Rpc.service));
//    }
//
//    public Integer sentRequestToMedApp(Message message, String service) {
//
//        try {
//            Rpc.RpcMessage rpcMessage = Rpc.RpcMessage
//                    .newBuilder()
//                    .setId(System.currentTimeMillis())
//                    .setService(service)
//                    .setVersion("1.0.0")
//                    .setPayloadClass(
//                            message.getClass().getSimpleName())
//                    .setPayloadData(message.toByteString()).build();
//            Buffer buf = new Buffer(rpcMessage.toByteArray());
//            final String id = "12345678";
//            byte[] idByte = id.getBytes(Charset.forName("UTF-8"));
//
//            buf.appendBytes(idByte).appendByte((byte) id.length());
//            vertx.eventBus()
//                    .send(service,
//                            buf,
//                            new Handler<org.vertx.java.core.eventbus.Message<byte[]>>() {
//                                @Override
//                                public void handle(org.vertx.java.core.eventbus.Message<byte[]> event) {
//
//
//                                }
//                            });
//            return 1;
//        } catch (Exception e) {
//            return 0;
//        }
//    }
//}
