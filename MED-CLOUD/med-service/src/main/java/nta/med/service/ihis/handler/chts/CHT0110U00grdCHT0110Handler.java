package nta.med.service.ihis.handler.chts;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.model.ihis.chts.CHT0110U00grdCHT0110ItemInfo;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;

@Service
@Scope("prototype")
public class CHT0110U00grdCHT0110Handler extends ScreenHandler<ChtsServiceProto.CHT0110U00grdCHT0110Request, ChtsServiceProto.CHT0110U00grdCHT0110Response> {
    private static final Log LOGGER = LogFactory.getLog(CHT0110U00grdCHT0110Handler.class);
    @Resource
    private Cht0110Repository cht0110Repository;
    @Resource
    private Adm0000Repository adm0000Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0110U00grdCHT0110Response handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0110U00grdCHT0110Request request) throws Exception {
        ChtsServiceProto.CHT0110U00grdCHT0110Response.Builder response = ChtsServiceProto.CHT0110U00grdCHT0110Response.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        String sangInx = request.getSangInx();
        if(!StringUtils.isEmpty(sangInx) && Language.JAPANESE.toString().equalsIgnoreCase(language))
		{
        	sangInx = adm0000Repository.callFnAdmConvertKanaFull(hospCode, sangInx);
		}
        String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<CHT0110U00grdCHT0110ItemInfo> listGrd = cht0110Repository.getCHT0110U00grdCHT0110ItemInfo(hospCode, sangInx, startNum, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (CHT0110U00grdCHT0110ItemInfo item : listGrd) {
                ChtsModelProto.CHT0110U00grdCHT0110ItemInfo.Builder info = ChtsModelProto.CHT0110U00grdCHT0110ItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdItem(info);
            }
        }
        return response.build();
    }
}