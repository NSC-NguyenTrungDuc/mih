package nta.med.service.integration.ocsa;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Ignore;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class DOC4003U00SaveLayoutTest extends MessageRequestTest {

	@Ignore
    @Test
    public void test() throws InterruptedException {
        OcsaModelProto.DOC4003U00GrdDOC4003Info.Builder item =  OcsaModelProto.DOC4003U00GrdDOC4003Info.newBuilder();
        item.setRowState(DataRowState.MODIFIED.getValue());
        item.setBunho("test");
        item.setPkdoc4003("test");
        OcsaServiceProto.DOC4003U00SaveLayoutRequest request = OcsaServiceProto.DOC4003U00SaveLayoutRequest.newBuilder().
                addSaveLayoutItem(item).build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }

}
