package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdPaListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0201U00LoadScreenHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00LoadScreenRequest, XrtsServiceProto.XRT0201U00LoadScreenResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00LoadScreenHandler.class);
    @Resource
    private CommonRepository commonRepository;
    @Resource
    private Adm3200Repository adm3200Repository;
    @Resource
    private Ocs0132Repository ocs0132Repository;

    @Override
    public boolean isValid(XrtsServiceProto.XRT0201U00LoadScreenRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        } else if (!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00LoadScreenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00LoadScreenRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00LoadScreenResponse.Builder response = XrtsServiceProto.XRT0201U00LoadScreenResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        //cbxActor
        List<ComboListItemInfo> listCbxActor = adm3200Repository.getUserIdUserNameInfo("XRT", "3", hospitalCode, true, request.getQueryDate());
        if (!CollectionUtils.isEmpty(listCbxActor)) {
            for (ComboListItemInfo item : listCbxActor) {
                XrtsModelProto.XRT0201U00CbxActorItemInfo.Builder info = XrtsModelProto.XRT0201U00CbxActorItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setUserId(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setUserName(item.getCodeName());
                }
                response.addCbxActorItemInfo(info);
            }
        }

        //grdPaList
        String jundalPart = request.getJundalPart();
        if (StringUtils.isEmpty(request.getJundalPart())) {
            jundalPart = "%";
        }
        List<XRT0201U00GrdPaListItemInfo> listGrdPaList = ocs0132Repository.getXRT0201U00GrdPaListItem(hospitalCode, language,
                request.getIoGubun(), request.getActGubun(), request.getJundalTableCode(), jundalPart, request.getBunho(),
                DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD));
        if (!CollectionUtils.isEmpty(listGrdPaList)) {
            for (XRT0201U00GrdPaListItemInfo item : listGrdPaList) {
                XrtsModelProto.XRT0201U00GrdPaListItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdPaListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (!StringUtils.isEmpty(item.getOrderTime()))
                	info.setOrderTime(getOrderTime(item.getOrderTime()));
                response.addGrdPaListItemInfo(info);
            }
        }
        return response.build();
    }
    
    private String getOrderTime(String time) {
    	String time1 = time.substring(0, 2);
    	String time2 = time.substring(2, time.length());
    	return time1 + ":" + time2;
    }
}