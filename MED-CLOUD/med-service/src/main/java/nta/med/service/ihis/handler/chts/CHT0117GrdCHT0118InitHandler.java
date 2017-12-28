package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.data.model.ihis.chts.CHT0117GrdCHT0118InitListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;
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
public class CHT0117GrdCHT0118InitHandler extends ScreenHandler<ChtsServiceProto.CHT0117GrdCHT0118InitRequest, ChtsServiceProto.CHT0117GrdCHT0118InitResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117GrdCHT0118InitHandler.class);
    @Resource
    private Cht0118Repository cht0118Repository;
    public boolean isValid(ChtsServiceProto.CHT0117GrdCHT0118InitRequest request, Vertx vertx, String clientId, String sessionId) {
    	if(StringUtils.isEmpty(request.getOffset())){
			return false;
		}
		return true;
    }

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117GrdCHT0118InitResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117GrdCHT0118InitRequest request) throws Exception {
        ChtsServiceProto.CHT0117GrdCHT0118InitResponse.Builder response = ChtsServiceProto.CHT0117GrdCHT0118InitResponse.newBuilder();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
        List<CHT0117GrdCHT0118InitListItemInfo> listResult = cht0118Repository.getCHT0117GrdCHT0118InitListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                request.getBuwi(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD), startNum, CommonUtils.parseInteger(request.getOffset()));
        if (!CollectionUtils.isEmpty(listResult)) {
            for (CHT0117GrdCHT0118InitListItemInfo item : listResult) {
                ChtsModelProto.CHT0117GrdCHT0118InitListItemInfo.Builder info = ChtsModelProto.CHT0117GrdCHT0118InitListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListItemInfo(info);
            }
        }
        return response.build();
    }
}