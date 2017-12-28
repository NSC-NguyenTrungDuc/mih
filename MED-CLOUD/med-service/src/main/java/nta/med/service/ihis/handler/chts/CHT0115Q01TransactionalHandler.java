package nta.med.service.ihis.handler.chts;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cht.Cht0115;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto.CHT0115Q01grdCHT0115Info;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class CHT0115Q01TransactionalHandler extends ScreenHandler<ChtsServiceProto.CHT0115Q01TransactionalRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0115Q01TransactionalHandler.class);
    @Resource
    private Cht0115Repository cht0115Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0115Q01TransactionalRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        for (CHT0115Q01grdCHT0115Info item : request.getListInfoList()) {
            if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                String result = cht0115Repository.getCht0115Q01TransactionModifiedChk(getHospitalCode(vertx, sessionId), item.getSusikCode());
                if (!StringUtils.isEmpty(result)) {
                    response.setResult(false);
                    response.setMsg(item.getSusikCode());
                    throw new ExecutionException(response.build());
                } else {
                    response.setResult(insertCht0115(item, request.getUserId(), hospitalCode));
                }
            } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                if (updateCht0115(item, request.getUserId(), hospitalCode)) {
                    response.setResult(true);
                } else {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                if (deleteCht0115(item, request.getUserId(), hospitalCode)) {
                    response.setResult(true);
                } else {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        return response.build();
    }

    public boolean insertCht0115(CHT0115Q01grdCHT0115Info item, String userId, String hospitalCode) {
        Cht0115 cht0115 = new Cht0115();
        cht0115.setSysDate(new Date());
        cht0115.setSysId(userId);
        cht0115.setUpdDate(new Date());
        cht0115.setUpdId(userId);
        cht0115.setHospCode(hospitalCode);
        cht0115.setSusikCode(item.getSusikCode());
        cht0115.setSusikName(item.getSusikName());
        cht0115.setSusikNameGana(item.getSusikNameGana());
        if (!StringUtils.isEmpty(item.getSusikCrDate()) && DateUtil.toDate(item.getSusikCrDate(), DateUtil.PATTERN_YYMMDD) != null) {
            cht0115.setSusikCrDate(DateUtil.toDate(item.getSusikCrDate(), DateUtil.PATTERN_YYMMDD));
        }
        if (!StringUtils.isEmpty(item.getSusikUpdDate()) && DateUtil.toDate(item.getSusikUpdDate(), DateUtil.PATTERN_YYMMDD) != null) {
            cht0115.setSusikUpdDate(DateUtil.toDate(item.getSusikUpdDate(), DateUtil.PATTERN_YYMMDD));
        }
        if (!StringUtils.isEmpty(item.getSusikCrDate()) && DateUtil.toDate(item.getSusikCrDate(), DateUtil.PATTERN_YYMMDD) != null) {
            cht0115.setSusikDisableDate(DateUtil.toDate(item.getSusikDisableDate(), DateUtil.PATTERN_YYMMDD));
        }
        cht0115.setSusikGwanriNo(item.getSusikGwanriNo());
        cht0115.setSusikGubun(item.getSusikGubun());
        cht0115.setSusikChangeCode(item.getSusikChangeCode());
        cht0115.setSusikDetailGubun(item.getSusikDetailGubun());
        if (!StringUtils.isEmpty(item.getStartDate()) && DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD) != null) {
            cht0115.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
        }
        if (!StringUtils.isEmpty(item.getEndDate()) && DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD) != null) {
            cht0115.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
        }
        if (!StringUtils.isEmpty(item.getSort()) && CommonUtils.parseDouble(item.getSort()) != null) {
            cht0115.setSort(CommonUtils.parseDouble(item.getSort()));
        }
        cht0115Repository.save(cht0115);
        return true;
    }

    public boolean updateCht0115(CHT0115Q01grdCHT0115Info item, String userId, String hospitalCode) {
        if (cht0115Repository.updateCht0115Q01TransactionModified(
                userId,
                item.getSusikName(),
                item.getSusikNameGana(),
                DateUtil.toDate(item.getSusikCrDate(), DateUtil.PATTERN_YYMMDD),
                DateUtil.toDate(item.getSusikUpdDate(), DateUtil.PATTERN_YYMMDD),
                DateUtil.toDate(item.getSusikDisableDate(), DateUtil.PATTERN_YYMMDD),
                item.getSusikGwanriNo(),
                item.getSusikGubun(),
                item.getSusikChangeCode(),
                item.getSusikDetailGubun(),
                DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD),
                CommonUtils.parseDouble(item.getSort()),
                hospitalCode,
                item.getSusikCode(),
                DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD)) > 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean deleteCht0115(CHT0115Q01grdCHT0115Info item, String userId, String hospitalCode) {
        if (cht0115Repository.deleteCht0115Q01TransactionDeleted(
                hospitalCode,
                item.getSusikCode(),
                DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD)) > 0) {
            return true;
        } else {
            return false;
        }
    }
}