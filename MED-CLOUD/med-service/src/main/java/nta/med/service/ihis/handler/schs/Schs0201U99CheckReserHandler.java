//package nta.med.service.ihis.handler.schs;
//
//import nta.med.core.infrastructure.socket.handler.ScreenHandler;
//import nta.med.core.utils.BeanUtils;
//import nta.med.data.dao.medi.ocs.Ocs1003Repository;
//import nta.med.data.dao.medi.out.Out0101Repository;
//import nta.med.data.model.ihis.common.ComboListItemInfo;
//import nta.med.data.model.ihis.emr.OCS1003P01LaySaveLayoutListItemInfo;
//import nta.med.data.model.ihis.schs.Schs0201U99InsertResultInfo;
//import nta.med.data.model.ihis.schs.SchsSCH0201Q01ReserListItemInfo;
//import nta.med.service.ihis.proto.*;
//import org.apache.commons.lang.StringUtils;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.transaction.annotation.Transactional;
//import org.vertx.java.core.Vertx;
//
//import javax.annotation.Resource;
//import java.util.List;
//
///**
// * @author DEV-TiepNM
// */
//@Service
//@Scope("prototype")
//@Transactional
//public class Schs0201U99CheckReserHandler  extends ScreenHandler<SchsServiceProto.Schs0201U99CheckReserRequest,  SchsServiceProto.Schs0201U99CheckReserResponse>
//{
//    @Resource
//    Out0101Repository out0101Repository;
//    @Resource
//    Ocs1003Repository ocs1003Repository;
//    @Override
//    public SchsServiceProto.Schs0201U99CheckReserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SchsServiceProto.Schs0201U99CheckReserRequest request) throws Exception {
//
//        SchsServiceProto.Schs0201U99CheckReserResponse.Builder response = SchsServiceProto.Schs0201U99CheckReserResponse.newBuilder();
//        if(!StringUtils.isEmpty(request.getPkout1001()))
//        {
//            List<Schs0201U99InsertResultInfo> schs0201U99InsertResultInfoList = out0101Repository.getSchs0201U99InsertResultInfo(request.getHospCode(), request.getPkout1001());
//
//
//            for(Schs0201U99InsertResultInfo item : schs0201U99InsertResultInfoList){
//                SchsModelProto.Schs0201U99InsertResultInfo.Builder info = SchsModelProto.Schs0201U99InsertResultInfo.newBuilder();
//                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
//                response.addInsItem(info);
//            }
//
//
//        }
//        OCS1003P01LaySaveLayoutListItemInfo ocs1003P01LaySaveLayoutListItemInfo = ocs1003Repository.
//                getListOCS1003P01LaySaveLayoutListItemInfo(getHospitalCode(vertx, sessionId), request.getFFksch0201());
//
//        OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo.Builder info = OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo.newBuilder();
//
//        BeanUtils.copyProperties(ocs1003P01LaySaveLayoutListItemInfo, info, getLanguage(vertx, sessionId));
//        response.setSaveItem(info);
//
//        return response.build();
//    }
//}
