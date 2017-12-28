package nta.med.service.ihis.handler.xrts;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.xrt.Xrt0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0101U00SaveLayoutInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;

@Service
@Scope("prototype")
@Transactional
public class XRT0101U00SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0101U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U00SaveLayoutHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        try{
        	if(!isValidKey(request, vertx, clientId, sessionId)){
        		response.setMsg("XRT0102_DUPLICATE_KEY");
        		response.setResult(false);
        		return response.build();
        	}

            String hospitalCode = getHospitalCode(vertx, sessionId);
            String language = getLanguage(vertx, sessionId);
            for (XRT0101U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
                if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                    result = insertXrt0102(info, request.getUserId(), hospitalCode, language);
                    result = 1;
                } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                    result = xrt0102Repository.updateXrt0102XRT0101U00ExecuteCase2(hospitalCode, language, request.getUserId(),
                            info.getCode2(), info.getCodeName(), CommonUtils.parseDouble(info.getSeq()), info.getCodeValue(), info.getCodeType(), info.getCode());
                } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                    result = xrt0102Repository.deleteXrt0102XRT0101U00ExecuteCase2(hospitalCode, language, info.getCodeType(), info.getCode());
                }
            }
        }
        catch (Exception e)
        {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }

        response.setResult(result != null && result > 0);
        return response.build();
    }

    private Integer insertXrt0102(XRT0101U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        try {
            Xrt0102 xrt0102 = new Xrt0102();
            xrt0102.setSysDate(new Date());
            xrt0102.setSysId(userId);
            xrt0102.setUpdDate(new Date());
            xrt0102.setUpdId(userId);
            xrt0102.setHospCode(hospitalCode);
            xrt0102.setLanguage(language);
            if (!StringUtils.isEmpty(info.getCodeType())) {
                xrt0102.setCodeType(info.getCodeType());
            }
            if (!StringUtils.isEmpty(info.getCode())) {
                xrt0102.setCode(info.getCode());
            }
            xrt0102.setCodeName(info.getCodeName());
            xrt0102.setCode2(info.getCode2());
            xrt0102.setCodeName2(null);
            xrt0102.setSeq(CommonUtils.parseDouble(info.getSeq()));
            xrt0102.setCodeValue(info.getCodeValue());
            xrt0102Repository.save(xrt0102);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0101 " + e.getMessage(), e);
            throw new ExecutionException(e.getMessage(), e);
        }
    }
    
    public boolean isValidKey(XrtsServiceProto.XRT0101U00SaveLayoutRequest request, Vertx vertx, String clientId, String sessionId){
    	for (XRT0101U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                boolean existed = xrt0102Repository.isExistedXrt0102(getHospitalCode(vertx, sessionId), info.getCodeType(), info.getCode(), getLanguage(vertx, sessionId));
                if(existed){
                	LOGGER.info("XRT0101U00SaveLayoutRequest: XRT0102_DUPLICATE_KEY: hospCode=" + getHospitalCode(vertx, sessionId) + ", codeType=" + info.getCodeType() + ", code=" + info.getCode()
                	+ ", language=" + getLanguage(vertx, sessionId));
                	return false;
                }
            } 
    	}
    	return true;
    }
}