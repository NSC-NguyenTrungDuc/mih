package nta.med.service.ihis.handler.xrts;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.xrt.Xrt0101;
import nta.med.core.domain.xrt.Xrt0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0101Repository;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class XRT0101U01SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0101U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U01SaveLayoutHandler.class);
    @Resource
    private Xrt0101Repository xrt0101Repository;
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U01SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        try
        {
            String userId = request.getUserId();
            List<XrtsModelProto.XRT0101U01GrdMcodeListItemInfo> listMCode = request.getInputMCodeList();
            String hospitalCode = getHospitalCode(vertx, sessionId);
            String language = getLanguage(vertx, sessionId);
            if (!CollectionUtils.isEmpty(listMCode)) {
                for (XrtsModelProto.XRT0101U01GrdMcodeListItemInfo item : listMCode) {
                    if (DataRowState.ADDED.getValue().equals(item.getRowState())) {
                        insertXrt0101(item, userId, hospitalCode, language);
                    } else if (DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
                        if (xrt0101Repository.updateXrt0101XRT0101U01ExecuteCase1(userId, item.getCodeTypeName(), item.getAdminGubun(), item.getCodeType(), language) <= 0) {
                            throw new ExecutionException(response.build());
                        }
                    } else if (DataRowState.DELETED.getValue().equals(item.getRowState())) {
                        if (xrt0101Repository.deleteXrt0101XRT0101U00ExecuteCase1(item.getCodeType(), language) <= 0) {
                            throw new ExecutionException(response.build());
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }

        response.setResult(true);
        return response.build();
    }

    public void insertXrt0101(XrtsModelProto.XRT0101U01GrdMcodeListItemInfo item, String userId, String hospitalCode, String language) {
        Xrt0101 xrt0101 = new Xrt0101();
        xrt0101.setSysDate(new Date());
        xrt0101.setSysId(userId);
        xrt0101.setUpdDate(new Date());
        xrt0101.setUpdId(userId);
        xrt0101.setCodeType(item.getCodeType());
        xrt0101.setCodeTypeName(item.getCodeTypeName());
        xrt0101.setAdminGubun(item.getAdminGubun());
        xrt0101.setLanguage(language);
        xrt0101Repository.save(xrt0101);
    }

    public void insertXrt0102(XrtsModelProto.XRT0101U01GrdDcodeListItemInfo item, String userId, String hospitalCode, String language) {
        Xrt0102 xrt0102 = new Xrt0102();
        xrt0102.setSysDate(new Date());
        xrt0102.setSysId(userId);
        xrt0102.setUpdDate(new Date());
        xrt0102.setUpdId(userId);
        xrt0102.setHospCode(hospitalCode);
        xrt0102.setCodeType(item.getCodeType());
        xrt0102.setCode(item.getCode());
        xrt0102.setCodeName(item.getCodeName());
        xrt0102.setCode2(item.getCode2());
        xrt0102.setSeq(CommonUtils.parseDouble(item.getSeq()));
        xrt0102.setCodeValue(item.getCodeValue());
        xrt0102.setLanguage(language);
        xrt0102Repository.save(xrt0102);
    }
    
    @Override
    @Route(global = false)
    public SystemServiceProto.UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		XrtsServiceProto.XRT0101U01SaveLayoutRequest request, SystemServiceProto.UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	String userId = request.getUserId();
        List<XrtsModelProto.XRT0101U01GrdDcodeListItemInfo> listDCode = request.getInputDCodeList();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
    	try {
	        if (!CollectionUtils.isEmpty(listDCode)) {
	            for (XrtsModelProto.XRT0101U01GrdDcodeListItemInfo item : listDCode) {
	                if (DataRowState.ADDED.getValue().equals(item.getRowState())) {
	                    insertXrt0102(item, userId, hospitalCode, language);
	                } else if (DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
	                    if (xrt0102Repository.updateXrt0102XRT0101U00ExecuteCase2(hospitalCode, language, userId, item.getCode2(), item.getCodeName(), CommonUtils.parseDouble(item.getSeq()), item.getCodeValue(), item.getCodeType(), item.getCode()) <= 0) {
	                        throw new ExecutionException(response.build());
	                    }
	                } else if (DataRowState.DELETED.getValue().equals(item.getRowState())) {
	                    if (xrt0102Repository.deleteXrt0102XRT0101U00ExecuteCase2(hospitalCode, language, item.getCodeType(), item.getCode()) <= 0) {
	                        throw new ExecutionException(response.build());
	                    }
	                }
	            }
	        }
    	}
        catch (Exception e)
        {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }

        response.setResult(true);
    	return response.build();
    }
}