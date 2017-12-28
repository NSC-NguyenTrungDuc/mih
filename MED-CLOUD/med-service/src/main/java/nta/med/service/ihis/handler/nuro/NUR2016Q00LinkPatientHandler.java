package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out2016;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
@Transactional
public class NUR2016Q00LinkPatientHandler extends ScreenHandler<NuroServiceProto.NUR2016Q00LinkPatientRequest, SystemServiceProto.UpdateResponse> {
    @Resource
    Out2016Repository out2016Repository;
    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2016Q00LinkPatientRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder updateResponse = SystemServiceProto.UpdateResponse.newBuilder();
        try
        {
            NuroModelProto.NUR2016Q00LinkPatientInfo info = request.getLinkPatientItem();
        	boolean patientLinkYn =  out2016Repository.verifyPatientLinkYn(getHospitalCode(vertx, sessionId), info.getBunho(), info.getHospCodeLink(), info.getBunhoLink());
        	if(patientLinkYn){
        		updateResponse.setMsg("0");
        		updateResponse.setResult(false);
                return updateResponse.build();
        	}
        	
        	// -- INSERT 1
            Out2016 out2016 = new Out2016();
            out2016.setHospCode(getHospitalCode(vertx, sessionId));
            out2016.setBunho(info.getBunho());
            out2016.setHospCodeLink(info.getHospCodeLink());
            out2016.setBunhoLink(info.getBunhoLink());
            out2016.setEmrLinkFlg(CommonUtils.parseBigDecimal(info.getEmrLinkFlg()));
            out2016.setLinkType(info.getLinkType());
            out2016.setActiveFlg(CommonUtils.parseBigDecimal(info.getActiveFlg()));
            out2016.setSysId(getUserId(vertx, sessionId));
            out2016.setUpdId(getUserId(vertx, sessionId));
            out2016Repository.save(out2016);
            
            // -- INSERT 2
            Out2016 out2 = new Out2016();
            out2.setHospCode(info.getHospCodeLink());
            out2.setBunho(info.getBunhoLink());
            out2.setHospCodeLink(getHospitalCode(vertx, sessionId));
            out2.setBunhoLink(info.getBunho());
            out2.setEmrLinkFlg(CommonUtils.parseBigDecimal(info.getEmrLinkFlg()));
            out2.setLinkType(info.getLinkType());
            out2.setActiveFlg(CommonUtils.parseBigDecimal(info.getActiveFlg()));
            out2.setSysId(getUserId(vertx, sessionId));
            out2.setUpdId(getUserId(vertx, sessionId));
            out2016Repository.save(out2);
            
            updateResponse.setResult(true);
            return updateResponse.build();
        }
        catch (Exception e)
        {
        	updateResponse.setMsg(e.getMessage());
            updateResponse.setResult(false);
            throw new ExecutionException(updateResponse.build());
        }

    }
}
